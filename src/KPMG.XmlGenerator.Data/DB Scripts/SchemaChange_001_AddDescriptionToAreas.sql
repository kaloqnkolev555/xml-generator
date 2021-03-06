IF COL_LENGTH('dbo.cg_meta_area', 'description') IS NULL
  ALTER TABLE [dbo].[cg_meta_area] ADD [description] nvarchar(200) NULL;