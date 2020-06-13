select DepositGroup,MAX(MagicWandSize) from WizzardDeposits group by DepositGroup

select * from WizzardDeposits
select DepositGroup,SUM(DepositAmount) from WizzardDeposits group by DepositGroup

select DepositGroup,SUM(DepositAmount) from WizzardDeposits where MagicWandCreator = 'Ollivander family' group by DepositGroup


select DepositGroup,SUM(DepositAmount) as [TotalSum] from WizzardDeposits where MagicWandCreator = 'Ollivander family' group by DepositGroup having sum(DepositAmount) < 150000 
order by [TotalSum] DESC


select DepositGroup,MagicWandCreator,MIN(DepositCharge) as [MinDepositCharge] from WizzardDeposits group by DepositGroup,MagicWandCreator
order by MagicWandCreator,DepositGroup


select AgeGroup,COUNT(*) from(
select 
	case
		when Age <= 10 then '[0-10]'
		when Age between 11 and 20  then '[11-20]'
		when Age between 21 and 30 then '[21-30]'
		when Age between 31 and 40 then '[31-40]'
		when Age between 41 and 50 then '[41-50]'
		when Age between 51 and 60 then '[51-60]' 
		else '[61+]'
	end as [AgeGroup]
from WizzardDeposits
) as AgeGroupQuery
group by AgeGroup

select * from (
select SUBSTRING(FirstName,1,1) as [FirstLetter] from WizzardDeposits
where DepositGroup = 'Troll Chest'
) as [FirstLetter]
group by FirstLetter
order by FirstLetter ASC


select DepositGroup,case when  from WizzardDeposits
11 case when