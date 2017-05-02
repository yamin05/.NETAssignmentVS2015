IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_TotalCostsByEngineer')
DROP VIEW Report_TotalCostsByEngineer
GO
create view Report_TotalCostsByEngineer
as
select u.userid,isnull(I.TotalHours,0) TotalHours, isnull(I.TotalCosts,0) TotalCosts  from 
(select * from users ) u left join
(select userid, sum(InterventionHours) TotalHours, sum(InterventionCost) TotalCosts 
from interventions where status=3 group by userid) I on u.userid=i.userid



Go

IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_AverageCostsByEngineer')
DROP VIEW Report_AverageCostsByEngineer
GO
create view Report_AverageCostsByEngineer
as
select u.userid,isnull(I.AverageHours,0) AverageHours, isnull(I.AverageCosts,0) AverageCosts  from 
(select * from users ) u left join 
(select userid, Convert(decimal(10,2),sum(InterventionHours)/count(InterventionHours)) AverageHours, 
Convert(decimal(10,2),sum(InterventionCost)/count(InterventionCost)) AverageCosts 
from interventions where status=3 group by userid) I on u.userid=i.userid


GO

IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_CostsByDistrict')
DROP VIEW Report_CostsByDistrict
GO
create view Report_CostsByDistrict
as
select D.DistrictId, D.DistrictName,isnull(sum(I.InterventionCost),0) Costs,isnull(sum(I.InterventionHours),0) Hours from (
select '0' DistrictId, 'Urban Indonesia' DistrictName
union all
select '1','Rural Indonesia'
union all
select '2', 'Urban Papua New Guinea'
union all
select '3', 'Rural Papua New Guinea'
union all
select '4', 'Sydney'
union all
select '5', 'Rural New South Wales' ) D left join 
(select I.InterventionCost,I.InterventionHours,I.Status,C.ClientDistrict from Interventions I inner join Clients C on I.ClientId=C.ClientId where I.Status=3
) I on I.ClientDistrict=D.DistrictId group by D.DistrictId,D.DistrictName

GO
IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_MonthlyCostsforDistrict')
DROP VIEW Report_MonthlyCostsforDistrict
GO
create view Report_MonthlyCostsforDistrict
as
select D.DistrictId,D.DistrictName,m.Year, M.Month, 
isnull(sum(I.InterventionCost),0) MonthlyCosts, isnull(sum(I.InterventionHours),0) MonthlyHours from (
select '0' DistrictId, 'Urban Indonesia' DistrictName
union all
select '1','Rural Indonesia'
union all
select '2', 'Urban Papua New Guinea'
union all
select '3', 'Rural Papua New Guinea'
union all
select '4', 'Sydney'
union all
select '5', 'Rural New South Wales' ) D cross join 
(
select '2017' "Year",'01' "Month" union all select '2017' y,'02' union all select '2017' y,'03' union all select '2017' y,'04' 
union all select '2017' y,'05' union all select '2017' y,'06' union all select '2017' y,'07' union all select '2017' y,'08' 
union all select '2017' y,'09' union all select '2017' y,'10' union all select '2017' y,'11' union all select '2017' y,'12' ) M 
left join (select I.InterventionCost,I.InterventionHours,I.CreateDate,I.Status,C.ClientDistrict from Interventions I inner join Clients C on I.ClientId=C.ClientId 
where I.Status=3 ) I on I.ClientDistrict=D.DistrictId and month(I.CreateDate)=M.Month and year(I.CreateDate)=M.Year
group by D.DistrictId,D.DistrictName,m.Year, M.Month