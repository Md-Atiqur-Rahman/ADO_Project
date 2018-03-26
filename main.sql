use master
go
create database MainAdo
go
use MainAdo
go

create table Orders(
ID int primary key ,
Odate  nvarchar(50),
ShippingAdd nvarchar(50))
go
create table OrderDetails (
ID int primary key identity(1,1),
OId  int not null references Orders (ID) on update cascade on delete cascade , 
Pname nvarchar(50) not null,
Qty float not null,
UnitPrice money not null,
Discount real 
)
go

create Proc Sp_InsertData
@id int,@date  nvarchar(50),@add nvarchar(50),
@name nvarchar(50),@qty float,@price money,
@dis real
As
Begin
declare @Oid int
insert into [dbo].[Orders] (ID,Odate,ShippingAdd)
values (@id,@date,@add);
select @Oid= @@IDENTITY
if(@id>0)
	Begin
		insert into OrderDetails(OId, Pname,Qty,UnitPrice,Discount)
		VALUES(@id,@name,@qty,@price,@dis)
	End
End


go
create proc Sp_DisplayData
@sdate nvarchar(50),@edate nvarchar(50)
As
Begin
Select  Orders.ID ,Pname,ShippingAdd,
Odate,Qty,UnitPrice,Discount
from Orders
inner join OrderDetails
on Orders.ID=OrderDetails.OId
where Odate between @sdate and @edate
order by Orders.ID desc
End
exec Sp_DisplayData '2017-02-05','2018-12-30'
go

create Proc Sp_UpdateData
@id int,
@date  nvarchar(50),@add nvarchar(50),
@name nvarchar(50),@qty float,@price money,
@dis real
As
Begin

Update [dbo].[Orders] set Odate=@date,
ShippingAdd= @add 
where ID =@id

Update  OrderDetails set Pname=@name
,Qty=@qty,UnitPrice=@price,Discount=@dis
		where OId = @id

End



go

create Proc Sp_DeleteData
@id int
 
As
Begin

delete from [dbo].[Orders]
where ID = @id
delete from [dbo].[OrderDetails]
where OID = @id

End

--exec Sp_DeleteData 1



go
create view vw_pro_information
as
select o.Id,od.Pname,o.ShippingAdd,o.Odate,od.Qty,od.UnitPrice,od.Discount
from [dbo].[Orders] o
inner join [dbo].[OrderDetails] od
on o.Id=od.OID

