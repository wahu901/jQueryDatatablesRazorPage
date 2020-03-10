truncate table PersonalInfo
---SQL loop insert 
DECLARE @ID int =0; 
DECLARE @StartDate AS DATETIME = '1980-01-01' 
WHILE @ID < 20
BEGIN 
insert into PersonalInfo values('First Name ' + _
CAST(@ID AS nvarchar),'Last Name ' + CAST(@ID AS VARCHAR),dateadd(day,1, @StartDate), 
'City ' + CAST(@ID AS VARCHAR),'Country ' + CAST(@ID AS VARCHAR),_
 ABS(CAST(NEWID() AS binary(12)) % 1000) + 5555, 
ABS(CAST(NEWID() AS binary(12)) % 1000) + 99998888,'email' + _
    CAST(@ID AS nvarchar) +'@gmail.com',
GETDATE(),null,'Admin' + CAST(@ID AS VARCHAR),null,1) 
SET @ID = @ID + 1; 
set @StartDate=dateadd(day,1, @StartDate) 
END