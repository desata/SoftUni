--1. Number of Users for Email Provider
--Find number of users for email provider from the largest to smallest, then by Email Provider in ascending order. 

select * from Users

select distinct
SUBSTRING(Email, CHARINDEX('@', EMAIL)+1, LEN(Email)) as [Email Provider]
from Users
