CREATE TABLE chinhanh (
	macn nvarchar(50)  primary key,
	tencn nvarchar(50)  not null,
	diachi nvarchar(50)  not null,
	sdt nvarchar(50)  not null,
	quanly nvarchar(50)  not null
)
CREATE TABLE nhanvien (
	manv nvarchar(50)  not null primary key,
	macn nvarchar(50)  not null foreign key references chinhanh(macn),
	tennv nvarchar(50)  not null,
	tuoi int not null,
	gioitinh nvarchar(50)  not null,
	diachi nvarchar(50)  not null,
	luong int not null,
	maquanly nvarchar(50)  not null,
	matkhau nvarchar(50)  not null
)

CREATE TABLE taikhoan(
	matk nvarchar(50)  not null primary key,
	tentk nvarchar(50)  not null,
	tuoi int not null,
	diachi nvarchar(50)  not null,
	sdt nvarchar(50)  not null,
	cmnd nvarchar(50)  not null,
	gioitinh nvarchar(50) not null,
	ngaycap datetime not null,
	noicap nvarchar(50)  not null
)
CREATE TABLE phieukh (
	maphieukh nvarchar(50)  not null primary key,
	magd nvarchar(50)  not null foreign key references giaodich(magd),
	tengd nvarchar(50)  not null,
	diachi nvarchar(50)  not null,
	sdt nvarchar(50)  not null,
	sotien int not null
)

CREATE TABLE loaigd (
	loaigd nvarchar(50)  not null primary key,
	tengd nvarchar(50)  not null
)
CREATE TABLE giaodich (
	magd nvarchar(50) not null primary key,
	macn nvarchar(50)  not null foreign key references chinhanh(macn),
	manv nvarchar(50)  not null foreign key references nhanvien(manv),
	matk nvarchar(50)  not null foreign key references taikhoan(matk),
	loaigd nvarchar(50)  not null foreign key references loaigd(loaigd),
	thoigian datetime not null,
	sotien int not null

)
CREATE TABLE phieugd (
	maphieudg nvarchar(50)  not null primary key,
	matk nvarchar(50)  not null foreign key references taikhoan(matk),
	manv nvarchar(50)  not null foreign key references nhanvien(manv),
	magd nvarchar(50)  not null foreign key references giaodich(magd),
	tengd nvarchar(50)  not null,
	sotien int not null,
	thoigian datetime not null,
)
select *from taikhoan
select *from nhanvien
select *from loaigd
select *from giaodich--
select *from chinhanh
select *from phieugd--
select *from phieukh--


create proc naptien

@sotien int
as
begin
	update giaodich set sotien = sotien +@sotien 
	
end