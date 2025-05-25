CREATE DATABASE db_ecommerce_dev
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

COMMENT ON DATABASE db_ecommerce_dev
    IS 'creacion de base de datos ecommerce';