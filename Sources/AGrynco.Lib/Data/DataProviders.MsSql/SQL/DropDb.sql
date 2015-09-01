IF EXISTS(
       SELECT *
       FROM   sys.databases
       WHERE  NAME = '@dbName'
   )
BEGIN
    ALTER DATABASE [@dbName] 
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE [@dbName]
END