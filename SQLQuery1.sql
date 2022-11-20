create table list(ID INT IDENTITY(1,1) Primary Key, Title VARCHAR(100), SubTitle VARCHAR(100), Date DateTime);



insert into list(Title,SubTitle,Date) values('Fitness','Week2',11/20/2022);

update list set Date = '11/20/2022' where ID = 1;
update list set Date = '11/20/2022' where ID = 2;

select * from list;