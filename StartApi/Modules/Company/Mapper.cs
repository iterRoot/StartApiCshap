using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StartApi.Core;


namespace StartApi.Modules.Company;
public class CompanyMapper : Profile
{
    public CompanyMapper()
    {
        CreateMap<Company, CompanyListResponse>();
        CreateMap<Company, CompanyDetailResponse>();
        CreateMap<Company, CompanyInsertRequest>();
        CreateMap<Company, CompanyUpdateRequest>();
        
        CreateMap<CompanyListResponse, Company>();
        CreateMap<CompanyDetailResponse, Company>();
        CreateMap<CompanyInsertRequest, Company>();
        CreateMap<CompanyUpdateRequest, Company>();

    }
    
}