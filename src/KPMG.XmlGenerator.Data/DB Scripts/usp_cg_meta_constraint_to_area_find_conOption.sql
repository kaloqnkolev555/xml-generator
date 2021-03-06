SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_constraint_to_area_find_conOption]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_constraint_to_area_find_conOption];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 26/09/2019
-- Revised date: 
-- Description : Find constraint by conOption and ref_version_id and return conOptions
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_constraint_to_area_find_conOption]
	(@ref_version_id int,
     @page_size int = 50,
	 @skip int = 0,
     @filter nvarchar(255) = NULL)
AS
BEGIN
  SET NOCOUNT ON

  SELECT DISTINCT [conOption] 
  FROM [dbo].[cg_meta_constraint_to_area] 
  WHERE [ref_version_id] = @ref_version_id AND
		[conOption] LIKE 
			CASE 
				WHEN @filter IS NULL THEN '%' 
				ELSE '%' + @filter + '%' 
			END
  ORDER BY [conOption]
  OFFSET @skip ROWS 
  FETCH NEXT @page_size ROWS ONLY;

END