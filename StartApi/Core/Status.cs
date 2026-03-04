namespace StartApi.Core;

public enum EStatus
{
    Inactive,
    Active,
    Pending,
    Archived,
    Deleted
}

public enum ERole
{
    Manager,
    SupperAdmin,
    Admin,
    Customer,
    Supplier,
    Guest,
    Developer
}