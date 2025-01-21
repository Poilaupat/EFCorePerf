using EFCorePerf.Data;
using EFCorePerf.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using AutoMapper;
using EFCorePerf.Business;

namespace EFCorePerf
{
#pragma warning disable 8603

    [MemoryDiagnoser]
    public class EFCoreBenchmark
    {
        private readonly long _requestId = 1;
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<EFCoreBenchmarkMapperProfile>();
        }).CreateMapper();

        public static void Init(int nbTransactions)
        {
            using (var context = new DataContextEager())
            {
                var populator = new Populator(context);
                populator.PopulateDb(nbTransactions);
            }
        }

        [Benchmark]
        public void RunGetEntityEager()
        {
            var requestEntity = GetRequestEntityEager(_requestId);

            //Slide 1
            var reason = requestEntity
                    .Transactions
                    .First()
                    .Cheques
                    .Where(x => x.Reason is not null)
                    .First()
                    .Reason;
        }

        [Benchmark]
        public void RunGetEntityLazy()
        {
            var requestEntity = GetRequestEntityLazy(_requestId);

            //Slide 1.1
            var reason = requestEntity
                    .Transactions
                    .First()
                    .Cheques
                    .Where(x => x.Reason is not null)
                    .First()
                    .Reason;
        }

        public void RunGetEntityExplicit()
        {
            var requestEntity = GetRequestEntityExplicit(_requestId);

            //Slide 1.1
            var tranCount = requestEntity
                    .Transactions
                    .Count();
        }

        [Benchmark]
        public void RunGetBusinessEager()
        {
            var requestBusiness = GetRequestBusinessEager(_requestId);
        }

        [Benchmark]
        public void RunGetBusinessLazy()
        {
            var requestBusiness = GetRequestBusinessLazy(_requestId);
        }

        [Benchmark]
        public void RunGetEntityEagerAsSplitQuery()
        {
            var requestEntity = GetRequestEntityEagerAsSplitQuery(_requestId);
        }


        private RequestEntity GetRequestEntityLazy(long requestId)
        {
            using (var context = new DataContextLazy())
            {
                var requestEntity = context
                    .Requests
                    .Find(requestId);

                //Slide 1.2
                //var reason = requestEntity
                //    .Transactions
                //    .First()
                //    .Cheques
                //    .Where(x => x.Reason is not null)
                //    .First()
                //    .Reason;

                return requestEntity;
            }
        }

        private RequestEntity GetRequestEntityEager(long requestId)
        {
            using (var context = new DataContextEager())
            {
                // Slide 1.1
                var request = context
                    .Requests
                    .Find(requestId);


                // Slide 1.2
                //var request = context.Requests
                //    .Include(x => x.Transactions).ThenInclude(x => x.Cheques).ThenInclude(x => x.Reason)
                //    .Include(x => x.Transactions).ThenInclude(x => x.Deposits)
                //    .Single(x => x.Id == requestId);

                return request;
            }
        }

        private RequestEntity GetRequestEntityExplicit(long requestId)
        {
            using (var context = new DataContextEager())
            {
                // Slide 1.1
                var request = context
                    .Requests
                    .Find(requestId);

                context
                    .Entry(request)
                    .Collection(r => r.Transactions)
                    .Load();

                return request;
            }
        }

        private RequestEntity GetRequestEntityEagerAsSplitQuery(long requestId)
        {
            using (var context = new DataContextEager())
            {
                var request = context.Requests
                    .Include(x => x.Transactions).ThenInclude(x => x.Cheques).ThenInclude(x => x.Reason)
                    .Include(x => x.Transactions).ThenInclude(x => x.Deposits)
                    .AsSplitQuery()
                    .Single(x => x.Id == requestId);

                return request;
            }
        }

        private Request GetRequestBusinessLazy(long requestId)
        {
            //Slide 2
            using (var context = new DataContextLazy())
            {
                var requestEntity = context
                    .Requests
                    .Find(requestId);


                return _mapper.Map<Request>(requestEntity);
            }
        }

        private Request GetRequestBusinessEager(long requestId)
        {
            using (var context = new DataContextEager())
            {
                var requestEntity = context.Requests
                    .Include(x => x.Transactions).ThenInclude(x => x.Cheques).ThenInclude(x => x.Reason)
                    .Include(x => x.Transactions).ThenInclude(x => x.Deposits)
                    .Single(x => x.Id == requestId);

                return _mapper.Map<Request>(requestEntity);
            }
        }
    }
}
