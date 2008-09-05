/****** Object:  StoredProcedure [odps].[OD_RPS_Invoice_message]    Script Date: 08/05/2008 10:13:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
-- Definition for stored procedure OD_RPS_Invoice_message : 
--

create procedure [odps].[OD_RPS_Invoice_message](@in_message char(1000))
AS
BEGIN
  select out_message=@in_message
end
GO
