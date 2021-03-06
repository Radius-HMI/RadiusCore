-- *** Standard Query
SELECT ID
    ,SignalID
    ,TagName
    ,InsertTime
    ,TimeStamp
    ,Value
FROM dataTblSignalHistory

-- *** Combine based on same Time stamp
SELECT TimeStamp,
	FlowRate = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = '59B7A6DE-D12D-48F1-80CF-75D7465AC628' AND TimeStamp = Q.TimeStamp),
	StaticPressure = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = '7FFCCD82-35E2-49B9-82A0-1E68DE122E90' AND TimeStamp = Q.TimeStamp),
	StaticPressure2 = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = '7F03725E-42AB-4991-A7F0-D2B81F624B57' AND TimeStamp = Q.TimeStamp),
	DiffPressure = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F' AND TimeStamp = Q.TimeStamp)
FROM dataTblSignalHistory Q
--WHERE TimeStamp <= '2017-05-15 19:52:41.173' AND TimeStamp >= '2017-05-15 19:52:32.383'
GROUP BY TimeStamp
ORDER BY TimeStamp DESC

-- *** Gets the most recent Values
SELECT GETDATE() as CurrentTime,DiffPressure,FlowingTemperature,FlowRate,StaticPressure
FROM
(
	-- This is the source table and should contain your filters
	SELECT Value, Tagname FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '59B7A6DE-D12D-48F1-80CF-75D7465AC628' ORDER BY TimeStamp DESC) AS tblFlowRate
	UNION
	SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '026D5C4E-A175-49CD-A56D-CFDB895C35B1' ORDER BY TimeStamp DESC) AS tblFlowingTemperature
	UNION
	SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '7FFCCD82-35E2-49B9-82A0-1E68DE122E90' ORDER BY TimeStamp DESC) AS tblStaticPressure
	UNION
	SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F' ORDER BY TimeStamp DESC) AS tblDiffPressure
) AS SourceTable
PIVOT
(
	-- The MIN or MAX function is needed to aggregate a varchar, but you can use other functions such as AVG for a numeric type
	MAX(Value)
	FOR TagName IN (DiffPressure,FlowingTemperature,FlowRate,StaticPressure,TestTag)
) AS PivotTable



-- *** Experiments
SELECT Value, Tagname FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '59B7A6DE-D12D-48F1-80CF-75D7465AC628' ORDER BY TimeStamp DESC) AS tbl1
UNION
SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '7FFCCD82-35E2-49B9-82A0-1E68DE122E90' ORDER BY TimeStamp DESC) AS tbl2
UNION
SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F' ORDER BY TimeStamp DESC) AS tbl3


-- 
SELECT TimeStamp,
	FlowRate = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = '59B7A6DE-D12D-48F1-80CF-75D7465AC628' AND TimeStamp = Q.TimeStamp),
	StaticPressure = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = '7FFCCD82-35E2-49B9-82A0-1E68DE122E90' AND TimeStamp = Q.TimeStamp),
	StaticPressure2 = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = '7F03725E-42AB-4991-A7F0-D2B81F624B57' AND TimeStamp = Q.TimeStamp),
	DiffPressure = (SELECT Value FROM dataTblSignalHistory WHERE SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F' AND TimeStamp = Q.TimeStamp)
FROM dataTblSignalHistory Q
--WHERE TimeStamp <= '2017-05-15 19:52:41.173' AND TimeStamp >= '2017-05-15 19:52:32.383'
GROUP BY TimeStamp
ORDER BY TimeStamp DESC


-- The Select Statement will contain the row and table name
SELECT 'RTU1_Properties' AS AllRTU1_Properties,
-- The PropertyID entries are used for the column names
DiffPressure,FlowingTemperature,FlowRate,StaticPressure
FROM
(
	-- This is the source table and should contain your filters
	SELECT Value, Tagname FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '59B7A6DE-D12D-48F1-80CF-75D7465AC628' ORDER BY TimeStamp DESC) AS tblFlowRate
	UNION
	SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '026D5C4E-A175-49CD-A56D-CFDB895C35B1' ORDER BY TimeStamp DESC) AS tblFlowingTemperature
	UNION
	SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = '7FFCCD82-35E2-49B9-82A0-1E68DE122E90' ORDER BY TimeStamp DESC) AS tblStaticPressure
	UNION
	SELECT Value,TagName FROM (SELECT TOP 1 Value,TagName FROM dataTblSignalHistory WHERE SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F' ORDER BY TimeStamp DESC) AS tblDiffPressure
) AS SourceTable
PIVOT
(
	-- The MIN or MAX function is needed to aggregate a varchar, but you can use other functions such as AVG for a numeric type
	MAX(Value)
	FOR TagName IN (DiffPressure,FlowingTemperature,FlowRate,StaticPressure,TestTag)
) AS PivotTable




  --SELECT TimeStamp,
  --     TestTag= ISNULL((SELECT Value FROM dataTblSignalHistory WHERE SignalID = '7F03725E-42AB-4991-A7F0-D2B81F624B57' AND TimeStamp =
  --Q.TimeStamp),NULL),
  --     StaticPressure= ISNULL((SELECT Value FROM dataTblSignalHistory WHERE SignalID = '7FFCCD82-35E2-49B9-82A0-1E68DE122E90' AND TimeStamp =
  --Q.TimeStamp),NULL),
  --     FlowRate= ISNULL((SELECT Value FROM dataTblSignalHistory WHERE SignalID = '59B7A6DE-D12D-48F1-80CF-75D7465AC628' AND TimeStamp =
  --Q.TimeStamp),NULL),
  --     DiffPressure= ISNULL((SELECT Value FROM dataTblSignalHistory WHERE SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F' AND TimeStamp =
  --Q.TimeStamp),NULL)
  --   FROM dataTblSignalHistory Q
  --   GROUP BY TimeStamp


SELECT tblDP.TimeStamp
		,DPTagName
		,DPValue
		,tblTest.TimeStamp
		,TestTagName
		,TestValue
FROM
(SELECT ID
	,TagName AS 'DPTagName'
	,TimeStamp
	,Value AS 'DPValue'
FROM dataTblSignalHistory
WHERE TimeStamp >= '2016-05-25 00:00:00.000' AND TimeStamp <= '2017-05-15 19:53:41.670' AND SignalID = 'DA61DA6B-3208-42AF-BD5D-B3D3E4540C2F'
) AS tblDP
FULL JOIN
(SELECT ID
	,TagName AS 'TestTagName'
	,TimeStamp
	,Value AS 'TestValue'
FROM dataTblSignalHistory
WHERE TimeStamp >= '2016-05-25 00:00:00.000' AND TimeStamp <= '2017-05-15 19:53:41.670' AND SignalID = '7F03725E-42AB-4991-A7F0-D2B81F624B57'
) AS tblTest
ON tblDP.TimeStamp = tblTest.TimeStamp

SELECT SignalID
	,TimeStamp
	,NULL as FlowRate
	,Value AS FlowingTemperature
FROM dataTblSignalHistory
WHERE TagName = 'StaticPressure'
UNION
SELECT SignalID
	,TimeStamp
	,Value AS FlowRate
	,NULL as FlowingTemperature
FROM dataTblSignalHistory
WHERE TagName = 'FlowRate'
ORDER BY TimeStamp DESC


SELECT tblTestTag.SignalID
	,tblTestTag.TimeStamp
	,tblStaticPressure.Value AS StaticPress
	,tblTestTag.Value AS TestValue 
FROM
(SELECT SignalID
	,TimeStamp
	,Value
FROM dataTblSignalHistory
WHERE TagName = 'TestTag') AS tblTestTag
LEFT JOIN
(
	SELECT SignalID
		,TimeStamp
		,Value
	FROM dataTblSignalHistory
	WHERE TagName = 'DiffPressure'
) AS tblStaticPressure
ON tblStaticPressure.SignalID = tblTestTag.SignalID
  















  --***************** Get Signals
  SELECT dataTblSignals.ID
	,dataTblSignals.ReferenceID
	,dataTblSignals.CreationDate
	,tblProperties.InputSource
	,tblProperties.OutputSource
	,dataTblSignals.TagName
	,dataTblSignals.DisplayName
	,dataTblSignals.TimeStamp
	,dataTblSignals.RawValue
	,dataTblSignals.Source
	,dataTblSignals.Enabled
	,dataTblSignals.ItemDataType
	,tblProperties.CommChannel
	,tblProperties.EnableScaling
	,tblProperties.EU_Min
	,tblProperties.EU_Max
	,tblProperties.RawMin
	,tblProperties.RawMax
	,tblProperties.MinValue
	,tblProperties.MaxValue
	,tblProperties.Precision
	,tblProperties.Quality
	,tblProperties.Units
	,tblProperties.WriteSecurityLevel
FROM dataTblSignals
LEFT JOIN
(
	SELECT SignalID,InputSource,OutputSource,CommChannel,Quality,Units,
			Precision,EnableScaling,RawMin,RawMax,EU_Min,EU_Max,
			MinValue,MaxValue,WriteSecurityLevel
	FROM
	(
		SELECT Name, Value,SignalID FROM cfgTblSignalProperties
	) AS SourceTable
	PIVOT
	(
		MAX(Value)
		FOR Name IN (InputSource,OutputSource,CommChannel,Quality,Units,
			Precision,EnableScaling,RawMin,RawMax,EU_Min,EU_Max,
			MinValue,MaxValue,WriteSecurityLevel)
	) AS PivotTable
) AS tblProperties
ON tblProperties.SignalID = dataTblSignals.ID
WHERE ReferenceID = '7686991F-F4D5-40F7-B62D-0C12E84DA4BA'
ORDER BY TagName