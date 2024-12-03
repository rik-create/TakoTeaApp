-- If the Users table already exists and you want to add a unique constraint to the Username column
ALTER TABLE Users
ADD CONSTRAINT UC_Username UNIQUE (Username);