using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using crssAssetDV.Dtos;
using crssAssetDV.Models;

namespace crssAssetDV.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            
            Mapper.CreateMap<Device, DeviceDto>();
            
            Mapper.CreateMap<TypeOfDevice, TypeOfDeviceDto>();
            Mapper.CreateMap<RoleDevice, RoleDeviceDto>();
            Mapper.CreateMap<DamagedSelectOption, DamagedSelectOptionDto>();

            Mapper.CreateMap<People, PeopleDto>();

            Mapper.CreateMap<Loan, LoanDto>();
            Mapper.CreateMap<LoanType, LoanTypeDto>();
            Mapper.CreateMap<LoanNote, LoanNoteDto>();


            //DTo to Domain
            Mapper.CreateMap<DeviceDto, Device>()
            .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<TypeOfDeviceDto, TypeOfDevice>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<DamagedSelectOptionDto, DamagedSelectOption>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<PeopleDto, People>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<LoanDto, Loan>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<LoanTypeDto, Loan>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<LoanNoteDto, LoanNote>()
                .ForMember(c => c.Id, opt => opt.Ignore());



        }
    }
}