SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_technical_setting_find_nrfield]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_technical_setting_find_nrfield];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 27/09/2019
-- Revised date: 
-- Description : Find settings by nrfield and ref_version_id and return nrfields
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_technical_setting_find_nrfield]
	(@ref_version_id int,
     @page_size int = 50,
	 @skip int = 0,
     @filter nvarchar(255) = NULL)
AS
BEGIN
  SET NOCOUNT ON

  SELECT DISTINCT [nrfield] 
  FROM [dbo].[cg_meta_technical_setting] 
  WHERE [ref_version_id] = @ref_version_id AND
		[nrfield] LIKE 
			CASE 
				WHEN @filter IS NULL THEN '%' 
				ELSE '%' + @filter + '%' 
			END
  ORDER BY [nrfield]
  OFFSET @skip ROWS 
  FETCH NEXT @page_size ROWS ONLY;

END