SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_del_many]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_del_many];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 18/09/2019
-- Revised date:
-- Description : Delete a collection of objects by IdColumn value
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_del_many]
  (@IdColumns nvarchar(max), @ErrorCode int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	IF @IdColumns IS NULL OR LEN(@IdColumns) < 1
    BEGIN
     SET @ErrorCode = 402; -- No object to delete
     RETURN(-1)
    END

	SET @IdColumns = ','+@IdColumns+',';
	DECLARE @objectsToDelete TABLE ([objct_name] nvarchar(255) INDEX IX1 NONCLUSTERED,
                                    [ref_version_id] int INDEX IX2 NONCLUSTERED)

    INSERT INTO @objectsToDelete ([objct_name], [ref_version_id])
    SELECT [objct_name], [ref_version_id]
    FROM [dbo].[cg_meta_objct] obj WHERE CHARINDEX(','+cast(obj.IdColumn as varchar(30))+',', @IdColumns) > 0
    IF NOT EXISTS(SELECT * FROM @objectsToDelete)
    BEGIN
        SET @ErrorCode = 402; -- No object to delete
        RETURN(-1)
    END

	BEGIN TRAN

	DELETE v2o FROM [dbo].[cg_meta_variant_objct] v2o
    INNER JOIN @objectsToDelete obj
    ON v2o.[ref_version_id] = obj.[ref_version_id] AND
       v2o.[ref_objct_name] = obj.[objct_name]

	DELETE hConstr FROM [dbo].[cg_meta_hconstraint_to_area] hConstr
    INNER JOIN @objectsToDelete obj
    ON hConstr.[ref_version_id] = obj.[ref_version_id] AND
       hConstr.[ref_objct_name] = obj.[objct_name]

    DELETE constr FROM [dbo].[cg_meta_constraint_to_area] constr
    INNER JOIN @objectsToDelete obj
    ON constr.[ref_version_id] = obj.[ref_version_id] AND
       constr.[ref_objct_name] = obj.[objct_name]

	DELETE col FROM [dbo].[cg_meta_column] col
    INNER JOIN @objectsToDelete obj
    ON col.[ref_version_id] = obj.[ref_version_id] AND
       col.[ref_objct_name] = obj.[objct_name]

	DELETE areaToObj FROM [dbo].[cg_meta_area_to_objct] areaToObj
    INNER JOIN @objectsToDelete obj
    ON areaToObj.[ref_version_id] = obj.[ref_version_id] AND
       areaToObj.[ref_objct_id] = obj.[objct_name]

	DELETE setting FROM [dbo].[cg_meta_technical_setting] setting
    INNER JOIN @objectsToDelete obj
    ON setting.[ref_version_id] = obj.[ref_version_id] AND
       setting.[ref_objct_name] = obj.[objct_name]

    DELETE footer FROM [dbo].[cg_meta_header_footer] footer
    INNER JOIN @objectsToDelete obj
    ON footer.[ref_version_id] = obj.[ref_version_id] AND
        footer.[ref_table_name] = obj.[objct_name]

	DELETE obj FROM [dbo].[cg_meta_objct] obj
    INNER JOIN @objectsToDelete objToDel
    ON obj.[ref_version_id] = objToDel.[ref_version_id] AND
       obj.[objct_name] = objToDel.[objct_name]

	COMMIT
END
