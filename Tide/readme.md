## 下载潮汐数据生成excel文档

[目标网址](https://haichaobiao.com/)

类说明：
> PlaceParser类用于解析当前国家的钓鱼站点列表数据。  
> TideParser类用于获取当前钓鱼站点的潮汐列表数据。  
> Tide类用于获取潮汐数据列表  
方法说明：
>>1. addBook      添加工作簿
>>2. saveBook     |保存工作簿
>>3. addTable     |添加工作表
>>4. getPlaces    |获取站点列表
>>5. getData      |获取数据（按月）
>>6. parserData   |解析数据
>>7. parserByYear |解析数据（按年）    

使用过程中可以自由组合以上函数接口进行获取所需的数据列表，可参考test范例。  
注意，getData接口中的code默认utf-8传入，越南地区的为latin-1，具体请对应修改。
