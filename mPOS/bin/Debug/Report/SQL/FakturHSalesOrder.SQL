SELECT HSatuan.Kode AS Satuan, HSalesman.Nama AS Salesman, HBarang.Kode AS KDBarang, HBarang.Nama AS NmBarang, HSalesOrderD.*, HSalesOrder.Kode, HSalesOrder.Tanggal, HSalesOrder.TglTempo, HSalesOrder.Total, HSalesOrder.Reff, HKontak.Kode AS KDCustomer, HKontak.Nama AS NamaCustomer, HKontak.Alamat 
FROM HSalesOrder 
INNER JOIN HSalesOrderD ON HSalesOrder.NoID=HSalesOrderD.IDHeader 
LEFT JOIN HBarang ON HBarang.NoID=HSalesOrderD.IDBarang
LEFT JOIN HSatuan ON HSatuan.NoID=HSalesOrderD.IDSatuan
LEFT JOIN HKontak ON HKontak.NoID=HSalesOrder.IDCustomer 
LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HSalesOrder.IDSalesman 