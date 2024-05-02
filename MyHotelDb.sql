
use MyHotelDb;
select name from sysobjects where type='U';

select * from Rooms;
sp_help payments;

select*from Bookings;
delete from Bookings where BookingId=809;
select * from Bookings where BookingId=5;


--drop database MyHotelDb;

select * from Logins;
select * from Rooms where HotelId='HOT2002';
insert into Rooms values('HOT2002','Single',200,'Yes')
select * from Hotels;

select * from Payments;
select* from Rooms;
select* from Hotels;
delete from Hotels Where HotelID='Test5'

select * from Payments where BookingId=5;
select * from Bookings where BookingId=5;



select * from Payments where BookingId=5;

