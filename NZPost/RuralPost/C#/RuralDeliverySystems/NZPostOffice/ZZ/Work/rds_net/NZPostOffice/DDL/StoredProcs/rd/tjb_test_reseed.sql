/****** Object:  StoredProcedure [rd].[tjb_test_reseed]    Script Date: 08/05/2008 10:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[tjb_test_reseed]( @newseed int ) as 
BEGIN
    DBCC CHECKIDENT ('odps.t_payment_runs');
    select * from odps.t_payment_runs;
    DBCC CHECKIDENT ('odps.t_payment_runs', RESEED, @newseed );
    DBCC CHECKIDENT ('odps.t_payment_runs');
    insert into odps.t_payment_runs
        (pr_date, gl_posted, pr_ap_posted, pr_contract_no, POTS)
    values
        (200805020, 'N', 'N', 0, 'N');
    select * from odps.t_payment_runs;
END
GO
