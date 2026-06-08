-- ============================================================
-- Script: ALTER_sys_clausu_usux.sql
-- Proposito: Ampliar la columna sys_clausu_usux de VARCHAR(50)
--            a VARCHAR(100) para soportar el nuevo formato de
--            hash PBKDF2 v2$ (79 caracteres).
-- Version:   Galeno40 - Fase 1
-- Fecha:     2026-06-07
-- ============================================================
-- 
-- EJECUTAR EN CADA AMBIENTE (dev, QA, pre-prod, prod)
-- Antes de ejecutar, verificar que no haya locks:
--   SHOW FULL PROCESSLIST;
--
-- ============================================================

ALTER TABLE sysusuarios
    MODIFY sys_clausu_usux VARCHAR(100) NOT NULL
    COMMENT 'Clave del Usuario (hash PBKDF2 v2$ 79 chars)';

-- ============================================================
-- VERIFICACION:
--   DESCRIBE sysusuarios;
--   SELECT MAX(LENGTH(sys_clausu_usux)) FROM sysusuarios;
-- ============================================================
