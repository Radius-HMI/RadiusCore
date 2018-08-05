--CREATE TRIGGER [dbo].[tr_SignalHistory]
--   ON [dbo].dataTblSignals
--   AFTER UPDATE
--AS BEGIN
--	declare @ID uniqueidentifier
--	declare @Value nvarchar(50)
--	declare @TagName nvarchar(50)
--    SET NOCOUNT ON;
--    IF UPDATE (RawValue) 
--    BEGIN
--        select @ID = i.ID from inserted i
--        select @TagName = i.TagName from inserted i
--        select @Value = i.RawValue from inserted i
--		INSERT INTO dataTblSignalHistory(
--			SignalID
--			,TagName
--			,Value
--		) VALUES (
--			@ID
--			,@TagName
--			,@Value
--		)
--    END 
--END

ALTER TRIGGER [dbo].[tr_SignalHistory]
   ON [dbo].dataTblSignals
   AFTER UPDATE
AS BEGIN
    SET NOCOUNT ON;
    IF UPDATE (RawValue)
    BEGIN
        INSERT INTO dataTblSignalHistory (
			SignalID
			,TagName
			,Value
			,TimeStamp
			)
        SELECT S.ID, S.TagName, S.RawValue, S.TimeStamp FROM dataTblSignals S
        INNER JOIN Inserted I ON S.ID = I.ID
        INNER JOIN Deleted D ON S.ID = D.ID and S.ID = D.ID 
        WHERE I.RawValue <> D.RawValue
	END
END