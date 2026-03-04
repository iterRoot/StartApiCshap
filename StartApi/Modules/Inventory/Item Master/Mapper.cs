using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StartApi.Core;


namespace StartApi.Modules.Inventory.ItemMaster;
public class ItemMasterMapper : Profile
{
    public ItemMasterMapper()
    {
        CreateMap<ItemMaster, ItemMasterListResponse>();
        CreateMap<ItemMaster, ItemMasterDetailResponse>();
        CreateMap<ItemMaster, ItemMasterInsertRequest>();
        CreateMap<ItemMaster, ItemMasterUpdateRequest>();
        
        CreateMap<ItemMasterListResponse, ItemMaster>();
        CreateMap<ItemMasterDetailResponse, ItemMaster>();
        CreateMap<ItemMasterInsertRequest, ItemMaster>();
        CreateMap<ItemMasterUpdateRequest, ItemMaster>();

    }
    
}