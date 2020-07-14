USE [ForeignCurrencyMarket.FCMContext]
GO

/****** Object:  UserDefinedFunction [dbo].[GetCurrencyName]    Script Date: 14.07.2020 11:34:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetCurrencyName]
(
	-- Add the parameters for the function here
	-- <@Param1, sysname, @p1> <Data_Type_For_Param1, , int>
	@currency varchar(3),
	@dt date
)
RETURNS decimal
AS
BEGIN
	-- Declare the return variable here
	DECLARE @ResultVar float;

	-- Add the T-SQL statements to compute the return value here
	SELECT @ResultVar = Value 
	  from dbo.Currencies c 
	 where c.CharCode = @currency 
	   AND c.Date = @dt;
	
  RETURN @ResultVar;
END
GO


