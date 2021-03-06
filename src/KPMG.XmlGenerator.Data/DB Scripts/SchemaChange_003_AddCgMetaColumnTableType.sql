IF type_id('[dbo].[CgMetaColumnTableType]') IS NULL
BEGIN
    CREATE TYPE [dbo].[CgMetaColumnTableType] AS TABLE
    (
	    [area_name] nvarchar(255)
        , [column_name] nvarchar(255)
    );

END