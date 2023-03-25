exports('insert', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const id = await exports.oxmysql.insert_async(query, args)
      resolve({result: id, error: false, msg: ""});
    } catch (error) {
      console.log(error);
      resolve({result: -1, error: true, msg: error});
    }
  });
});

exports('prepare', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const result = await exports.oxmysql.prepare_async(query, args)
      resolve({result: result, error: false, msg: ""});
    } catch (error) {
      console.log(error);
      resolve({result: {}, error: true, msg: error});
    }
  });
});

exports('query', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const result = await exports.oxmysql.query_async(query, args)
      resolve({result: result, error: false, msg: ""});
    } catch (error) {
      console.log(error);
      resolve({result: {}, error: true, msg: error});
    }
  });
});

exports('scalar', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const result = await exports.oxmysql.scalar_async(query, args)
      resolve({result: result, error: false, msg: ""});
    } catch (error) {
      console.log(error);
      resolve({result: "", error: true, msg: error});
    }
  });
});

exports('single', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const row = await exports.oxmysql.single_async(query, args)
      resolve({result: row, error: false, msg: ""});
    } catch (error) {
      console.log(error);
      resolve({result: {}, error: true, msg: error});
    }
  });
});

exports('transaction', (queries, parameters) => {
  return new Promise(async (resolve) => {
    try {
      if(parameters){
        const success = await exports.oxmysql.transaction_async(queries, parameters)
        resolve({result: success, error: false, msg: ""});
      } else {
        const success = await exports.oxmysql.transaction_async(queries)
        resolve({result: success, error: false, msg: ""});
      }
    } catch (error) {
      console.log(error);
      resolve({result: false, error: true, msg: error});
    }
  });
});

exports('update', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const affectedRows = await exports.oxmysql.update_async(query, args)
      resolve({result: affectedRows, error: false, msg: ""});
    } catch (error) {
      console.log(error);
      resolve({result: [], error: true, msg: error});
    }
  });
});