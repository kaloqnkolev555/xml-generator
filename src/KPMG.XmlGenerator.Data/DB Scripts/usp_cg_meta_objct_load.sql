SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_load]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_load];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 01/10/2019
-- Revised date: 30/10/2019
-- Description : Load a record from [dbo].[cg_meta_objct] and related tables
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_load]
	(@IdColumn int = NULL,
	 @ref_version_id int = NULL,
	 @objct_name nvarchar(255) = NULL,
	 @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON;

  IF @IdColumn IS NULL
  BEGIN
	SELECT @IdColumn = [IdColumn]
	FROM [dbo].[cg_meta_objct]
	WHERE [objct_name] = @objct_name AND
		  [ref_version_id] = @ref_version_id;
  END

  IF @IdColumn IS NOT NULL
  BEGIN
    SELECT @objct_name = [objct_name], @ref_version_id = [ref_version_id] FROM [dbo].[cg_meta_objct] WHERE [IdColumn] = @IdColumn;

	SELECT
      obj.[ref_version_id] AS [VersionId],
      obj.[objct_name] AS [CgMetaObjectName],
      obj.[ref_group_name] AS [CgMetaGroupName],
      obj.[ref_table_name] AS [CgMetaTableName],
      obj.[is_footer] AS [IsFooter],
      obj.[Description] AS [Description],
      obj.[is_default] AS [IsDefault],
      obj.[IdColumn] AS [Id],

      footer.[footer_fileName] AS [FooterFileName],
      header.[IdColumn] AS [HeaderObjectId],
      footer.[ref_objct_name] AS [HeaderObjectName],
      footer.[footer_hashtotalField] AS [FooterHashTotalField],

      gr.[group_ID] AS [GroupId],
      gr.[group_lable] AS [GroupLabel],
      gr.[ref_report_id] AS [GroupReportId],
      gr.[extract] AS [GroupIsExtract],
      gr.[IdColumn] AS [GroupIdColumn]
	FROM [dbo].[cg_meta_objct] AS obj
	  INNER JOIN [dbo].[cg_meta_group] AS gr ON obj.[ref_group_name] = gr.[group_ID] AND obj.[ref_version_id] = gr.[ref_version_id]
	  LEFT OUTER JOIN [dbo].[cg_meta_header_footer] AS footer ON footer.[ref_table_name] = obj.[objct_name] AND footer.[ref_version_id] = obj.[ref_version_id]
	  LEFT OUTER JOIN [dbo].[cg_meta_objct] AS header ON header.[ref_version_id] = footer.[ref_version_id] AND header.[objct_name] = footer.[ref_objct_name]
	WHERE obj.[IdColumn] = @IdColumn;

    SELECT
      ts.[IdColumn] AS [Id],
      ts.[ref_version_id] AS [VersionId],
      ts.[ref_objct_name] AS [SettingObjectName],
      el.[extraction_logic_name] AS [ExtractionLogicName],
      el.[extraction_logic_description] AS [ExtractionLogicDescription],
      el.[IdColumn] AS [ExtractionLogicIdColumn],
      ts.[ref_helperTable_name] AS [HelperTableName],
      ts.[dayByDay] AS [DayByDay],
      ts.[daysPerLoop] AS [DaysPerLoop],
      ts.[nrobjct] AS [NrObject],
      ts.[nrfield] AS [NrField],
      ts.[nrMin] AS [NrMin],
      ts.[nrMax] AS [NrMax],
      ts.[parallel] AS [Parallel],
      ts.[pkgSize] AS [PkgSize],
      ts.[pkgSize2] AS [PkgSize2],
      ts.[xFilename] AS [XFilename],
      ts.[hashtotalField] AS [HashTotalField],
      ts.[is_default_setting] AS [IsDefaultSetting],
      ts.[docNbr] AS [DocNbr],
      ts.[loopAt] AS [LoopAt]
    FROM [dbo].[cg_meta_technical_setting] AS ts
      INNER JOIN [dbo].[cg_meta_extraction_logic] AS el ON el.[ref_version_id] = ts.[ref_version_id] AND el.[extraction_logic_name] = ts.[ref_extraction_logic_name]
    WHERE ts.[ref_version_id] = @ref_version_id AND ts.[ref_objct_name] = @objct_name;

	SELECT
      area.[IdColumn] AS [Id],
      area.[ref_version_id] AS [VersionId],
      area.[area_name] AS [AreaName],
      area.[description] AS [Description]
	FROM [dbo].[cg_meta_area] AS area
	  INNER JOIN [dbo].[cg_meta_area_to_objct] AS a2o ON a2o.[ref_version_id] = area.[ref_version_id] AND a2o.[ref_area_name] = area.[area_name]
    WHERE a2o.[ref_version_id] = @ref_version_id AND a2o.[ref_objct_id] = @objct_name;

	SELECT
      v.[ref_version_id] AS [VersionId],
      v.[variant_name] AS [VariantName],
      v.[description] AS [Description],
      v.[IdColumn] AS [Id],
      v2c.[configuration_name] AS [ConfigurationName],
      v2c.[IdColumn] AS [ConfigurationIdColumn]
	FROM [dbo].[cg_meta_variant] AS v
	INNER JOIN [dbo].[cg_meta_variant_objct] AS v2o	ON v2o.[ref_version_id] = v.[ref_version_id] AND v2o.[ref_variant_name] = v.[variant_name]
	FULL OUTER JOIN [dbo].[cg_meta_variant_config] AS v2c ON v2c.[ref_version_id] = v.[ref_version_id] AND v2c.[ref_variant_name] = v.[variant_name]
	WHERE v2o.[ref_version_id] = @ref_version_id AND v2o.[ref_objct_name] = @objct_name;

	SELECT
      constr.[ref_version_id] AS [VersionId],
      constr.[ref_extraction_logic_name] AS [ExtractionLogicName],
      constr.[conField] AS [ConField],
      constr.[conOption] AS [ConOption],
      constr.[conValue] AS [ConValue],
      constr.[InSQL] AS [InSQL],
      constr.[priority] AS [Priority],
      constr.[ref_area_id] AS [AreaName],
      area.[description] AS [AreaDescription],
      area.[IdColumn] AS [AreaIdColumn],
      constr.[IdColumn] AS [Id]
	FROM [dbo].[cg_meta_constraint_to_area] AS constr
    INNER JOIN [dbo].[cg_meta_area] AS area ON area.[ref_version_id] = constr.[ref_version_id] AND area.[area_name] = constr.[ref_area_id]
	WHERE constr.[ref_version_id] = @ref_version_id AND constr.[ref_objct_name] = @objct_name;

	SELECT
      col.[IdColumn] AS [Id],
      col.[ref_version_id] AS [VersionId],
      obj.[ref_table_name] AS [TableName],
      col.[column_name] AS [ColumnName],
      dd03l.[KEYFLAG] AS [KeyFlag],
      col.[ref_area_name] AS [AreaName],
      area.[description] AS [AreaDescription],
      area.[IdColumn] AS [AreaIdColumn]
	FROM [dbo].[cg_meta_column] AS col
	INNER JOIN [dbo].[cg_meta_objct] AS obj	ON obj.[ref_version_id] = col.[ref_version_id] AND obj.[objct_name] = col.[ref_objct_name]
    INNER JOIN [dbo].[cg_meta_area] AS area ON area.[ref_version_id] = col.[ref_version_id] AND area.[area_name] = col.[ref_area_name]
    LEFT OUTER JOIN [dbo].[DD03L] AS dd03l ON obj.[ref_table_name] = dd03l.[TABNAME] AND col.[column_name] = dd03l.[FIELDNAME]
	WHERE obj.[IdColumn] = @IdColumn;

    WITH
    hc_ordered AS (
      SELECT
        hc.*,
        a.[description] AS [AreaDescription],
        a.[IdColumn] AS [AreaIdColumn],
        ROW_NUMBER() OVER (ORDER BY hc.[ref_area_id], hc.[conLine], ISNULL(hc.[is_complex_line], 'ZZZ') DESC) AS hc_order
      FROM [dbo].[cg_meta_hconstraint_to_area] AS hc
        INNER JOIN [dbo].[cg_meta_area] AS a ON a.[ref_version_id] = hc.[ref_version_id] AND a.[area_name] = hc.[ref_area_id]
        INNER JOIN [dbo].[cg_meta_objct] AS o ON o.[objct_name] = hc.[ref_objct_name] AND o.[ref_version_id] = hc.[ref_version_id]
      WHERE o.[IdColumn] = @IdColumn
    ),
    hc_start AS (
      SELECT
        *,
        CASE WHEN ([is_complex_line] IS NULL OR [is_complex_line] = 'S') THEN ROW_NUMBER() OVER (ORDER BY [hc_order]) ELSE NULL END AS hc_rn
      FROM hc_ordered
    ),
    hc_cnt AS (
      SELECT
        *,
        COUNT(hc_rn) OVER (ORDER BY hc_order) AS cnt
      FROM hc_start
    ),
    hc_for_grouping AS (
      SELECT
        *,
        MAX(hc_rn) OVER (PARTITION BY cnt) AS [hc_group]
      FROM hc_cnt
    )

    SELECT
      MAX(g.[ref_version_id]) AS [VersionId],
      MAX(g.[hconstraint_name]) AS [HConstraintName],
      MAX(g.[ref_area_id]) AS [AreaName],
      MAX(g.[AreaDescription]) AS [AreaDescription],
      MAX(g.[AreaIdColumn]) AS [AreaIdColumn],
      CAST(CASE WHEN LEN(LTRIM(COALESCE(MAX(g.[is_default_no_constraint]), ''))) > 0 THEN 1 ELSE 0 END AS BIT) AS [IsDefaultNoConstraint],
      MAX(g.[priority]) AS [Priority],
      STUFF(
        (SELECT
           CHAR(10) + [conContent]
         FROM hc_for_grouping AS g2
         WHERE g2.[hc_group] = g.[hc_group]
         FOR XML PATH(''), TYPE)
        .value('(./text())[1]','nvarchar(260)'),
        1, 1, ''
      ) AS [ConstraintContent]
    FROM
      hc_for_grouping AS g
    GROUP BY g.[hc_group];

	SELECT
		[DD03L].[TABNAME],
		[DD03L].[FIELDNAME],
		[DD03L].[KEYFLAG]
	FROM [dbo].[DD03L] AS [DD03L]
	INNER JOIN [dbo].[cg_meta_objct] AS [obj] ON [obj].[ref_table_name] = [DD03L].TABNAME
	WHERE obj.[IdColumn] = @IdColumn AND
		[DD03L].[FIELDNAME] NOT LIKE '.INCLU%'
    ORDER BY [DD03L].[KEYFLAG] DESC, [DD03L].[FIELDNAME];
END
ELSE
  BEGIN
  	SELECT @ErrorCode = 401; -- Object name is missing
    RAISERROR('Object name is missing', 16, 1)
  END

END