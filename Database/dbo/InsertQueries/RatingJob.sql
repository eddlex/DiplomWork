USE [msdb]
GO

BEGIN TRANSACTION
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0

-- Create a new job
DECLARE @JobID BINARY(16)
EXEC @ReturnCode = msdb.dbo.sp_add_job @job_name=N'ExpireRatingView', 
		@enabled=1, 
		@notify_level_eventlog=0, 
		@notify_level_email=2, 
		@notify_level_netsend=0, 
		@notify_level_page=0, 
		@delete_level=0, 
		@description=N'Your job description',
		@category_name=N'Database Maintenance', 
		@owner_login_name=N'sa', 
		@job_id = @JobID OUTPUT
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

-- Add a job step
EXEC @ReturnCode = msdb.dbo.sp_add_jobstep @job_id=@JobID, 
		@step_name=N'YourStepName', 
		@step_id=1, 
		@cmdexec_success_code=0, 
		@on_success_action=1, 
		@on_fail_action=2, 
		@retry_attempts=0, 
		@retry_interval=0, 
		@os_run_priority=0, @subsystem=N'TSQL', 
		@command=N'Your T-SQL Command', 
		@database_name=N'YourDatabaseName', 
		@flags=0
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

-- Add schedule to the job to run every hour
EXEC @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id=@JobID, 
		@name=N'YourScheduleName', 
		@enabled=1, 
		@freq_type=4, -- Daily frequency
		@freq_interval=1, -- Every day
		@freq_subday_type=8, -- Frequency once
		@freq_subday_interval=1, -- Every hour
		@freq_relative_interval=0, 
		@freq_recurrence_factor=1, 
		@active_start_date=20240331, 
		@active_end_date=99991231, 
		@active_start_time=0, 
		@active_end_time=235959, 
		@schedule_uid=N'your-schedule-uid'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

-- Add job to category
EXEC @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @JobID, @server_name = N'(local)'
IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

COMMIT TRANSACTION
GOTO EndSave
QuitWithRollback:
    IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
