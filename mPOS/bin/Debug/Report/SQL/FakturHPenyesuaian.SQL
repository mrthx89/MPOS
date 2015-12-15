SELECT HSatuan.Kode AS Satuan, HBarang.Kode AS KDBarang, HBarang.Nama AS NmBarang, HPenyesuaianD.*, HPenyesuaian.Kode, HPenyesuaian.Tanggal, HPenyesuaian.Total, HPenyesuaian.Reff 
FROM HPenyesuaian 
INNER JOIN HPenyesuaianD ON HPenyesuaian.NoID=HPenyesuaianD.IDHeader 
LEFT JOIN HBarang ON HBarang.NoID=HPenyesuaianD.IDBarang
LEFT JOIN HSatuan ON HSatuan.NoID=HPenyesuaianD.IDSatuan