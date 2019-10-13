ALTER TABLE Users
ADD CONSTRAINT check_PasswordBiggerThan5
  CHECK (LEN(Users.[Password]) > 5);