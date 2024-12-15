using AutoMapper;
using EFCorePerf.Business;
using EFCorePerf.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCorePerf
{
    internal class EFCoreBenchmarkMapperProfile : Profile
    {
        public EFCoreBenchmarkMapperProfile() 
        {
            CreateMap<RequestEntity, Request>();
            CreateMap<TransactionEntity, Transaction>();
            CreateMap<ChequeEntity, Cheque>();
            CreateMap<DepositEntity, Deposit>();
            CreateMap<ReasonEntity, Reason>();
        }
    }
}
