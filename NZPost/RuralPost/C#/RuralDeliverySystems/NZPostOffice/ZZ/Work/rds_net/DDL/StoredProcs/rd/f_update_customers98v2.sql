/****** Object:  StoredProcedure [rd].[f_update_customers98v2]    Script Date: 08/05/2008 10:16:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[f_update_customers98v2]
AS
BEGIN
set CONCAT_NULL_YIELDS_NULL off
  declare @vcust_id int,
  @vcust_rd_number char(45),
  @vcust_mail_town char(45),
  @vcust_surname_company char(45),
  @vcust_initials char(45),
  @vcust_title char(45),
  @vcust_property_identification char(45),
  @vcust_mailing_address_no char(45),
  @vcust_mailing_address_road char(45),
  @vcust_mailing_address_locality char(45),
  @vcust_phone_day char(45),
  @vcust_phone_night char(45),
  @vcust_phone_mobile char,
  @vcust_occupations char(45),
  @vcust_other_occupation char(45),
  @vcust_interests char(45),
  @vccust_other_interests char(45),
  @vcust_dir_listing_ind char(45),
  @vcust_survey98_timestamp datetime,
  @audit_cust_rd_number char(40),
  @audit_cust_mail_town char(45),
  @iTemp int,
  @iCNT int
  declare c1 cursor for select customer_survey98.cust_id,
      customer_survey98.cust_rd_number,
      customer_survey98.cust_mail_town,
      customer_survey98.cust_surname_company,
      customer_survey98.cust_initials,
      customer_survey98.cust_title,
      customer_survey98.cust_property_identification,
      customer_survey98.cust_mailing_address_no,
      customer_survey98.cust_mailing_address_road,
      customer_survey98.cust_mailing_address_locality,
      customer_survey98.cust_phone_day,
      customer_survey98.cust_phone_night,
      customer_survey98.cust_occupations,
      customer_survey98.cust_other_occupation,
      customer_survey98.cust_interests,
      customer_survey98.cust_dir_listing_ind,
      cust_mobile from
      customer_survey98 where
      exists(select customer.cust_id from customer where customer.cust_id = customer_survey98.cust_id) order by
      cust_id asc
  open c1
  if @@error <> 0
    begin
      rollback transaction
      return(-1)
    end
  /* Watcom only
  MAINLOOP98:
  */while 1=1 
    begin
      fetch next from c1 into @vcust_id,@vcust_rd_number,@vcust_mail_town,@vcust_surname_company,@vcust_initials,@vcust_title,
        @vcust_property_identification,@vcust_mailing_address_no,@vcust_mailing_address_road,@vcust_mailing_address_locality,
        @vcust_phone_day,@vcust_phone_night,@vcust_occupations,@vcust_other_occupation,@vcust_interests,
        @vcust_dir_listing_ind,@vcust_phone_mobile
      if @@error <> 0
        begin
          rollback transaction
          return(-1)
        end
      if @@fetch_status <0
        break
        /* Watcom only
        MAINLOOP98
        */
      select @audit_cust_rd_number = cust_rd_number,@audit_cust_mail_town = cust_mail_town,@vcust_survey98_timestamp = cust_survey98_timestamp from customer where cust_id = @vcust_id
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-2)
        end
      if @vcust_survey98_timestamp is null
        begin
          update customer set cust_survey98_timestamp = @vcust_survey98_timestamp where
            cust_id = @vcust_id
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-3)
            end
        end
      if left(@vcust_rd_number,3) = 'RD '
        select @vcust_rd_number=right(@vcust_rd_number,case when len(rd.trim(@vcust_rd_number)) >=3 then len(rd.trim(@vcust_rd_number)) else 3 end-3)
      if left(@vcust_rd_number,2) = 'RD'
        select @vcust_rd_number=right(@vcust_rd_number,len(rd.trim(@vcust_rd_number))-2)
      if(@audit_cust_rd_number <> @vcust_rd_number) and(@audit_cust_mail_town <> @vcust_mail_town)
        begin
          insert into customer_survey98_transfers(cust_id,
            cust_rd_number_old,
            cust_mail_town_old,
            cust_rd_number_new,
            cust_mail_town_new) values(@vcust_id,
            @audit_cust_rd_number,
            @audit_cust_mail_town,
            @vcust_rd_number,
            @vcust_mail_town)
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-4)
            end
        end
      update customer set
        cust_rd_number = (case when @vcust_rd_number is not null then @vcust_rd_number else cust_rd_number end),
        cust_mail_town = (case when @vcust_mail_town is not null then @vcust_mail_town else cust_mail_town end),
        cust_surname_company = (case when @vcust_surname_company is not null then @vcust_surname_company else cust_surname_company end),
        cust_initials = (case when @vcust_initials is not null then @vcust_initials else cust_initials end),
        cust_title = (case when @vcust_title is not null then @vcust_title else cust_title end),
        cust_property_identification = (case when @vcust_property_identification is not null then @vcust_property_identification else cust_property_identification end),
        cust_mailing_address_no = (case when @vcust_mailing_address_no is not null then @vcust_mailing_address_no else cust_mailing_address_no end),
        cust_mailing_address_road = (case when @vcust_mailing_address_road is not null then @vcust_mailing_address_road else cust_mailing_address_road end),
        cust_mailing_address_locality = (case when @vcust_mailing_address_locality is not null then @vcust_mailing_address_locality else cust_mailing_address_locality end),
        cust_phone_day = (case when @vcust_phone_day is not null then @vcust_phone_day else cust_phone_day end),
        cust_phone_night = (case when @vcust_phone_night is not null then @vcust_phone_night else cust_phone_night end),
        cust_phone_mobile = (case when @vcust_phone_mobile is not null then @vcust_phone_mobile else cust_phone_mobile end),
        cust_dir_listing_ind = (case when @vcust_dir_listing_ind is not null then @vcust_dir_listing_ind else cust_dir_listing_ind end) where
        cust_id = @vcust_id
      if @@error <> 0 /* <> was < */
        begin
          rollback transaction
          return(-5)
        end
      select @vcust_interests=rd.trim(@vcust_interests)
      select @iTemp=1
      /* Watcom only
      whileloop:
      */while 1=1 
        begin
          if len(substring(@vcust_interests,@iTemp,1)) > 0
            if substring(@vcust_interests,@iTemp,1) = '1'
              begin
                insert into customer_interest(cust_id,interest_id) select @vcust_id,@iTemp where not exists(select c.cust_id from customer_interest as c where c.cust_id = @vcust_id and c.interest_id = @itemp)
                if @@error <> 0 /* <> was < */
                  begin
                    rollback transaction
                    return(-6)
                  end
              end
          else
            break
            /* Watcom only
            whileloop
            */
          select @iTemp=@iTemp+1
        end
      select @vcust_occupations=rd.trim(@vcust_occupations)
      select @iTemp=0
      /* Watcom only
      whileloop2:
      */while 1=1 
        begin
          select @iTemp=@iTemp+1
          if len(substring(@vcust_occupations,@iTemp,1)) > 0
            if substring(@vcust_occupations,@iTemp,1) = '1'
              if @iTemp <> 10
                begin
                  if @iTemp = 11
                    select @icnt = count(c.cust_id) from customer_occupation as c where c.cust_id = @vcust_id and c.occupation_id = 10
                  else
                    select @icnt = count(c.cust_id) from customer_occupation as c where c.cust_id = @vcust_id and c.occupation_id = @itemp
                  if @@error <> 0 /* <> was < */
                    begin
                      rollback transaction
                      return(-68)
                    end
                  if @icnt = 0
                    if @iTemp = 11
                      insert into customer_occupation(cust_id,occupation_id) values(@vcust_id,10)
                    else
                      insert into customer_occupation(cust_id,occupation_id) values(@vcust_id,@iTemp)
                  if @@error <> 0 /* <> was < */
                    begin
                      rollback transaction
                      return(-7)
                    end
                end
          else
            break
            /* Watcom only
            whileloop2
            */
        end
      if len(@vcust_other_occupation) > 0
        begin
          select @iTemp=0
          select @iTemp = occupation_id from occupation where soundex(occupation_description) = soundex(@vcust_other_occupation)
          if @@error <> 0 /* <> was < */
            begin
              rollback transaction
              return(-74)
            end
          if @iTemp > 0
            begin
              insert into customer_occupation(cust_id,occupation_id) select @vcust_id,@iTemp where not exists(select c.cust_id from customer_occupation as c where c.cust_id = @vcust_id and c.occupation_id = @itemp)
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-71)
                end
            end
          else
            begin
              insert into occupation(occupation_id,occupation_description) values(null,@vcust_other_occupation)
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-72)
                end
              select @iTemp = occupation_id from occupation where occupation_description = @vcust_other_occupation
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-75)
                end
              insert into customer_occupation(cust_id,occupation_id) select @vcust_id,@iTemp 
              if @@error <> 0 /* <> was < */
                begin
                  rollback transaction
                  return(-73)
                end
            end
        end
    end
  close c1
  commit transaction
  return(1)
end
GO
