create table ������������
(
�����_������������ int primary key,
������� nvarchar(50) not null,
������� nvarchar(50) not null,
��� nvarchar(50) not null,
�������� nvarchar(50) not null,
����� nvarchar(50) not null,
�����_�������� nvarchar(25) not null,
����_�������� date not null
)


create table ����� 
(
�����_����� int primary key,
�������� nvarchar(50) not null,
����_������ decimal(25,2) not null,
��������_����� nvarchar(50) not null,
������� int not null
)


create table �����������_������
(
����_������������ int,
����� nvarchar(50) not null,
����� nvarchar(50) not null,
��� int not null,
���������� int not null,
�������� int not null,
��������_������ nvarchar(100) not null,
primary key(����_������������, ��������_������), 
foreign key (����_������������) references  ������������(�����_������������)
)

create table ������� 
(
����_������������ int,
�����_������� int,
���������� int not null,
primary key(����_������������, �����_�������),
foreign key (����_������������) references ������������(�����_������������),
foreign key(�����_�������) references �����(�����_�����)
)

create table �����
(
�����_������ int,
����_������������ int,
�����_������  int,
����_�_�����_�������� datetime not null,
������ nvarchar(50) not null,
���������� int not null,
primary key(�����_������, ����_������������, �����_������),
foreign key(����_������������) references ������������(�����_������������),
foreign key(�����_������) references �����(�����_�����)
)

