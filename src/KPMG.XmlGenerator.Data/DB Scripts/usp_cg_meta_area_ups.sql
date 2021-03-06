SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_area_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_area_ups];
GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 27/09/2019
-- Description : Map object(s) to area 
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_area_ups]
  (@ref_version_id int,@area_name nvarchar(255),@MapMetaObjctIdColumns nvarchar(max)=NULL,@IdColumn int=NULL,@NewIdColumn int OUTPUT, @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

	IF @IdColumn is NOT NULL
	BEGIN
	
		-- fetch area name and area/object version
		SELECT @ref_version_id = [ref_version_id], @area_name = [area_name] FROM [dbo].[cg_meta_area] WHERE [IdColumn] = @IdColumn;

		-- Check if area exists
		IF @area_name IS NOT NULL AND LEN(LTRIM(RTRIM(@area_name))) > 0
		BEGIN
	      
		  -- check if something needs to be mapped
          IF @MapMetaObjctIdColumns IS NULL OR LTRIM(@MapMetaObjctIdColumns) = ''
          BEGIN
		    -- delete mappings
		    DELETE [dbo].[cg_meta_area_to_objct]
			  WHERE [ref_version_id] = @ref_version_id
				    AND [ref_area_name] = @area_name;
            RETURN;
          END

          SET @MapMetaObjctIdColumns = ','+@MapMetaObjctIdColumns+',';

          DECLARE @objct_names TABLE([objct_name] nvarchar(255));

          INSERT INTO @objct_names ([objct_name])
            SELECT [objct_name]
              FROM [dbo].[cg_meta_objct]
              WHERE CHARINDEX(','+cast([IdColumn] as varchar(30))+',', @MapMetaObjctIdColumns) > 0;

          -- delete unmapped
          DELETE [dbo].[cg_meta_area_to_objct]
			  WHERE [ref_version_id] = @ref_version_id
				    AND [ref_area_name] = @area_name
                    AND [ref_objct_id] NOT IN (SELECT [objct_name] FROM @objct_names);
          
          -- insert newly mapped
          INSERT INTO [dbo].[cg_meta_area_to_objct]
            ([ref_version_id], [ref_area_name], [ref_objct_id])
            SELECT DISTINCT @ref_version_id, @area_name, [objct_name]
              FROM @objct_names
              WHERE [objct_name] NOT IN (SELECT [ref_objct_id] FROM [dbo].[cg_meta_area_to_objct] WHERE [ref_version_id] = @ref_version_id AND [ref_area_name] = @area_name);
		END
		ELSE
			SELECT @ErrorCode = 101; -- Area name is missing
	END
	ELSE 
		SELECT @ErrorCode = 104; -- No area was selected to update object mapping

  COMMIT
END