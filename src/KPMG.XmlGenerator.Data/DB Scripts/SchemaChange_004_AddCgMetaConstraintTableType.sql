IF type_id('[dbo].[CgMetaConstraintTableType]') IS NULL
BEGIN
    CREATE TYPE [dbo].[CgMetaConstraintTableType] AS TABLE
    (
	    [constraintField] nvarchar(255)
	    , [constraintOption] nvarchar(255)
	    , [constraintValue] nvarchar(255)
	    , [area_name] nvarchar(255)
        , [InSQL] bit
	    , [priority] int
    );
END