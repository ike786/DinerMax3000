DELETE FROM Menu_MenuItem
WHERE MenuItemId IN (SELECT id FROM MenuItem WHERE Name = 'dfsfd')
DELETE FROM MenuItem WHERE Name = 'dfsfd'