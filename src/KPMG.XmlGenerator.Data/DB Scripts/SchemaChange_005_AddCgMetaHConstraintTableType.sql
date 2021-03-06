IF type_id('[dbo].[CgMetaHConstraintTableType]') IS NULL
BEGIN
    CREATE TYPE [dbo].[CgMetaHConstraintTableType] AS TABLE
    (
	    [hconstraint_name] nvarchar(255),
	    [conLine] int,
	    [conContent] nvarchar(255),
	    [area_name] nvarchar(255),
        [priority] int,
	    [is_complex_line] nvarchar(15),
	    [is_default_no_constraint] nvarchar(15)
    );
END

GO