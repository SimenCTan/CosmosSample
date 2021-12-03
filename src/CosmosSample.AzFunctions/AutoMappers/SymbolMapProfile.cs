using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CosmosSample.Domain.Entities;
using CosmosSample_AzFunctions.ViewModels;

namespace CosmosSample_AzFunctions.AutoMappers
{
    public class SymbolMapProfile : Profile
    {
        public SymbolMapProfile()
        {
            CreateMap<DailyQuote, DailyQuoteViewModel>();
        }
    }
}
