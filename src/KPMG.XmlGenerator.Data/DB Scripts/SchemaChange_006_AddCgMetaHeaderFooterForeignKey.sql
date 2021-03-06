IF EXISTS (SELECT 1 FROM sys.foreign_keys
   WHERE object_id = OBJECT_ID(N'dbo.FK__cg_meta_header_f__3E48EDC1')
   AND parent_object_id = OBJECT_ID(N'dbo.cg_meta_header_footer')
)
	ALTER TABLE [dbo].[cg_meta_header_footer] DROP CONSTRAINT [FK__cg_meta_header_f__3E48EDC1]

IF EXISTS (SELECT 1 FROM sys.foreign_keys
   WHERE object_id = OBJECT_ID(N'dbo.FK__cg_meta_header_footer_cg_meta_obct_name')
   AND parent_object_id = OBJECT_ID(N'dbo.cg_meta_header_footer')
)
	ALTER TABLE [dbo].[cg_meta_header_footer] DROP CONSTRAINT FK__cg_meta_header_footer_cg_meta_obct_name

ALTER TABLE [dbo].[cg_meta_header_footer] ADD CONSTRAINT FK__cg_meta_header_footer_cg_meta_obct_name
	FOREIGN KEY ([ref_version_id], [ref_table_name]) REFERENCES [dbo].[cg_meta_objct]([ref_version_id], [objct_name]);

GO