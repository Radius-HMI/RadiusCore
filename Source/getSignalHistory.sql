USE [RadiusData]
GO

/****** Object:  StoredProcedure [dbo].[rGetSignalHistory]    Script Date: 5/16/2017 7:23:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		David Cox
-- Create date: 5/15/2017
-- Description:	Gets the available Signal History
-- =============================================
CREATE PROCEDURE [dbo].[rGetSignalHistory]
	-- Add the parameters for the stored procedure here
	@TagName uniqueidentifier = NULL
	,@SignalID uniqueidentifier = NULL
AS
BEGIN
	IF @SignalID IS NULL AND @TagName IS NULL
	BEGIN
		SELECT TagName 
		FROM dataTblSignalHistory
		GROUP BY TagName
	END
	ELSE IF @SignalID IS NULL
	BEGIN
		SELECT TOP 1000 SignalID
			,TimeStamp
			,Value
		FROM dataTblSignalHistory
		WHERE TagName = 'TestTag'
		ORDER BY TimeStamp DESC
	END
	ELSE
	BEGIN
		SELECT TOP 1000 TagName
			,TimeStamp
			,Value
		FROM dataTblSignalHistory
		WHERE SignalID = '7F03725E-42AB-4991-A7F0-D2B81F624B57'
		ORDER BY TimeStamp DESC
	END
END
GO

