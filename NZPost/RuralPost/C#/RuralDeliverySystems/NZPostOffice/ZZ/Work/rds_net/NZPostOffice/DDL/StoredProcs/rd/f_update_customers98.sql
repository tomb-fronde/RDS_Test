/****** Object:  StoredProcedure [rd].[f_update_customers98]    Script Date: 08/05/2008 10:16:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [rd].[f_update_customers98]
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
  @vcust_occupations char(45),
  @vcust_other_occupation char(45),
  @vcust_interests char(45),
  @vccust_other_interests char(45),
  @vcust_dir_listing_ind char(45),
  @vcust_survey98_timestamp datetime,
  @audit_cust_rd_number char(40),
  @audit_cust_mail_town char(45),
  @iTemp int
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
      customer_survey98.cust_other_interests,
      customer_survey98.cust_dir_listing_ind from
      customer_survey98
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
        @vcust_phone_day,@vcust_phone_night,@vcust_occupations,@vcust_other_occupation,@vcust_interests,@vccust_other_interests,
        @vcust_dir_listing_ind
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
        select @vcust_rd_number=right(@vcust_rd_number,case when len(rd.trim(@vcust_rd_number)) >=3 then len(rd.trim(@vcust_rd_number)) else 3 end -3)
      if left(@vcust_rd_number,2) = 'RD'
        select @vcust_rd_number=right(@vcust_rd_number,len(rd.trim(@vcust_rd_number))-2)
      if(@audit_cust_rd_number <> @vcust_rd_number) and(@audit_cust_mail_town <> @vcust_mail_town)
        begin
          insert into customer_survey98_transfers(cust_id,
            cust_rd_number_old,
            cust_mail_town_old,
            cust_rd_number_new,
            cust_mail_town_new) values(
            @vcust_rd_number,
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
        cust_rd_number = (case when len(@vcust_rd_number) > 0 then @vcust_rd_number else cust_rd_number end),
        cust_mail_town = (case when len(@vcust_mail_town) > 0 then @vcust_mail_town else cust_mail_town end),
        cust_surname_company = (case when  len(@vcust_surname_company) > 0 then @vcust_surname_company else cust_surname_company end),
        cust_initials = (case when len(@vcust_initials) > 0 then @vcust_initials else cust_initials end),
        cust_title = (case when len(@vcust_title) > 0 then @vcust_title else cust_title end),
        cust_property_identification = (case when len(@vcust_property_identification) > 0 then @vcust_property_identification else cust_property_identification end),
        cust_mailing_address_no = (case when len(@vcust_mailing_address_no) > 0 then @vcust_mailing_address_no else cust_mailing_address_no end),
        cust_mailing_address_road = (case when len(@vcust_mailing_address_road) > 0 then @vcust_mailing_address_road else cust_mailing_address_road end),
        cust_mailing_address_locality = (case when len(@vcust_mailing_address_locality) > 0 then @vcust_mailing_address_locality else cust_mailing_address_locality end),
        cust_phone_day = (case when len(@vcust_phone_day) > 0 then @vcust_phone_day else cust_phone_day end),
        cust_phone_night = (case when len(@vcust_phone_night) > 0 then @vcust_phone_night else cust_phone_night end),
        cust_dir_listing_ind = (case when len(@vcust_dir_listing_ind) > 0 then @vcust_dir_listing_ind else cust_dir_listing_ind end) where
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
                insert into customer_interest(cust_id,interest_id) values(@vcust_id,@iTemp)
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
      if len(@vccust_other_interests) > 0
        begin
          select @iTemp=0
          select @iTemp = interest_id from interest where soundex(interest_description) = soundex(@vccust_other_interests)
          if @iTemp > 0
            insert into customer_interest(cust_id,interest_id) values(@vcust_id,@iTemp)
          else
            begin
              insert into interest(interest_id,interest_description) values(null,@vccust_other_interests)
              insert into customer_interest(cust_id,interest_id) select @vcust_id,interest_id from interest where interest_description = @vccust_other_interests
            end
        end
      select @vcust_occupations=rd.trim(@vcust_occupations)
      select @iTemp=1
      /* Watcom only
      whileloop2:
      */while 1=1 
        begin
          if len(substring(@vcust_occupations,@iTemp,1)) > 0
            if substring(@vcust_occupations,@iTemp,1) = '1'
              begin
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
          select @iTemp=@iTemp+1
        end
      if len(@vcust_other_occupation) > 0
        begin
          select @iTemp=0
          select @iTemp = occupation_id from occupation where soundex(occupation_description) = soundex(@vcust_other_occupation)
          if @iTemp > 0
            insert into customer_occupation(cust_id,occupation_id) values(@vcust_id,@iTemp)
          else
            begin
              insert into occupation(occupation_id,occupation_description) values(null,@vcust_other_occupation)
              insert into customer_occupation(cust_id,occupation_id) select @vcust_id,occupation_id from occupation where occupation_description = @vcust_other_occupation
            end
        end
    end
  close c1
  return(1)
end
GO
