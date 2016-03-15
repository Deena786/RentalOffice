>>делается один раз за весь проект
enable-migrations -ContextTypeName RentalOfficeContext -MigrationsDirectory Migrations -ProjectName RentalOffice.Data  



 >>добавить текущая миграция
Add-Migration prd_user_roleMigration1 -ProjectName RentalOffice.Data
Add-Migration address2Migration -ProjectName RentalOffice.Data
Add-Migration address_userMigration -ProjectName RentalOffice.Data
Add-Migration change_userMigration -ProjectName RentalOffice.Data
Add-Migration order_Migration -ProjectName RentalOffice.Data
Add-Migration weird_Migration -ProjectName RentalOffice.Data
Add-Migration selectedItem_Migration -ProjectName RentalOffice.Data
Add-Migration orderItem_Migration -ProjectName RentalOffice.Data
Add-Migration order_Change_Migration -ProjectName RentalOffice.Data
Add-Migration change_orderItem_Migration -ProjectName RentalOffice.Data
Add-Migration change_2_orderItem_Migration -ProjectName RentalOffice.Data
Add-Migration change_Address_Migration -ProjectName RentalOffice.Data
Add-Migration change_Atribut_Migration -ProjectName RentalOffice.Data
Add-Migration change_OrderProduct_2_Migration -ProjectName RentalOffice.Data


>> внести изменения в базу 
Update-database -ProjectName RentalOffice.Data 
    

 >>откатить до указанной миграции миграция
Update-database -ProjectName RentalOffice.Data -TargetMigration _prd_user_role
