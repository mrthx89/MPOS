SELECT HJual.TotalPoin, HJual.Bayar, HJual.Sisa, HSatuan.Kode AS Satuan, HSalesman.Nama AS Salesman, HBarang.Kode AS KDBarang, HBarang.Nama AS NmBarang, HJualD.*, HJual.Kode, HJual.Tanggal, HJual.TglTempo, HJual.Total, HJual.Reff, HKontak.Kode AS KDCustomer, HKontak.Nama AS NamaCustomer, HKontak.Alamat 
FROM HJual
INNER JOIN HJualD ON HJual.NoID=HJualD.IDHeader 
LEFT JOIN HBarang ON HBarang.NoID=HJualD.IDBarang
LEFT JOIN HSatuan ON HSatuan.NoID=HJualD.IDSatuan
LEFT JOIN HKontak ON HKontak.NoID=HJual.IDCustomer 
LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HJual.IDSalesman 