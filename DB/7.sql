select [Email Provider],COUNT(*) as [Number Of Users] from
(
SELECT 
	
    SUBSTRING(email,CHARINDEX('@', email)+1,LEN(email)-CHARINDEX('@', email)) as [Email Provider]
FROM 
    Users
) as [Email Provider]
group by [Email Provider]
order by [Number Of Users] DESC,[Email Provider] ASC



select g.Name as Game,gt.Name as [Game Type],u.Username,ug.Level,ug.Cash,c.Name as [Character] 
from Users as u
join UsersGames as Ug on u.Id = ug.UserId 
join Games as g on g.Id = Ug.GameId 
join GameTypes as gt on gt.Id=g.GameTypeId 
join Characters as c on ug.CharacterId=c.Id
order by ug.Level DESC,u.Username,g.Name

select * from UserGameItems

select u.Username,g.Name as Game,COUNT(*) as lk
from Users as u
join UsersGames as Ug on u.Id = ug.UserId 
join Games as g on g.Id = Ug.GameId 
join GameTypes as gt on gt.Id=g.GameTypeId 
join Characters as c on ug.CharacterId=c.Id
join UserGameItems as ugi on ug.Id=ugi.UserGameId
join items as i on ugi.ItemId = i.Id
group by i.name