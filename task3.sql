use shop_pharmacy
create table users
(
User_number int primary key,
Nickname  nvarchar(50) not null,
Last_name nvarchar(50) not null,
Namee nvarchar(50) not null,
Patronymic nvarchar(50) not null,
Mail nvarchar(50) not null,
Phone_number nvarchar(25) not null,
Birthdate date not null
)
create table categories
(
Id_categories int primary key,
Category_name nvarchar(50) not null,
)

create table product 
(
Number_product int primary key,
Id_categories int not null,
Namee nvarchar(50) not null,
Product_price decimal(25,2) not null,
Product_description nvarchar(50) not null,
Article int not null,
foreign key (Id_categories) references  Categories(Id_categories),

)

create table filter
 (
 Id_categories int primary key,
 product_availability bit not null,
 release_form nvarchar(50) not null,
 availability_of_discounts bit not null,
 discounts int null,
 vacation_from_the_pharmacy nvarchar(20) not null,
 indications nvarchar(50) not null,
 producer nvarchar(20) not null,
 expiration_date nvarchar(25) not null,
 brand_name nvarchar(25) not null,
 quantity_in_pack int not null,
 Price decimal(25,2) not null,
 foreign key (Id_categories) references Categories(Id_categories)
 )

 create table saved_address
(
User_idd int,
City nvarchar(50) not null,
Street nvarchar(50) not null,
House int not null,
Construction int not null,
Flat int not null,
Address_name nvarchar(100) not null,
primary key(User_idd, Address_name), 
foreign key (User_idd) references  Users(User_number)
)

create table basket 
(
User_idd int,
Basket_number int,
Quantity_of_goods int not null,
primary key(User_idd, Basket_number),
foreign key (User_idd) references Users(User_number),
foreign key(Basket_number) references Product(Number_product)
)

create table ordering
(
Order_Number int,
User_idd int,
Number_product  int,
Date_and_Time_references datetime not null,
Statuss nvarchar(50) not null,
Quantity int not null,
primary key(Order_Number, User_idd, Number_product),
foreign key(User_idd) references Users(User_number),
foreign key(Number_product) references Product(Number_product)
)