using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StartApi.Core;


namespace StartApi.Modules.Tools.Fields;
public class FieldsMapper : Profile
{
    public FieldsMapper()
    {
        CreateMap<Fields, FieldsListResponse>();
        CreateMap<Fields, FieldsDetailResponse>();
        CreateMap<Fields, FieldsInsertRequest>();
        CreateMap<Fields, FieldsUpdateRequest>();
        
        CreateMap<FieldsListResponse, Fields>();
        CreateMap<FieldsDetailResponse, Fields>();
        CreateMap<FieldsInsertRequest, Fields>();
        CreateMap<FieldsUpdateRequest, Fields>();

    }
    
}