debug = true;

function CheckDebug(this_resource){
  try {
    const resources = GetConvar("mysql_debug");
    if (resources == "true") { return true; }
    for (const resource of JSON.parse(resources)) {
      if (resource == this_resource) { return true; }
    }
  } catch (error) { console.log("CheckDebug()", error); }
  return false;
}

exports('insert', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(query, args); }
      const id = await exports.oxmysql.insert_async(query, args);
      if (needs_debugging) { console.log(id); }
      resolve({result: id, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: -1, error: true, msg: error});
    }
  });
});

exports('prepare', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(query, args); }
      const result = await exports.oxmysql.prepare_async(query, args);
      if (needs_debugging) { console.log(result); }
      resolve({result: result, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: false, error: true, msg: error});
    }
  });
});

exports('query', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(query, args); }
      const result = await exports.oxmysql.query_async(query, args);
      if (needs_debugging) { console.log(result); }
      resolve({result: result, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: false, error: true, msg: error});
    }
  });
});

exports('scalar', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(query, args); }
      const result = await exports.oxmysql.scalar_async(query, args);
      if (needs_debugging) { console.log(result); }
      resolve({result: result, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: false, error: true, msg: error});
    }
  });
});

exports('single', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(query, args); }
      const row = await exports.oxmysql.single_async(query, args);
      if (needs_debugging) { console.log(row); }
      resolve({result: row, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: {}, error: true, msg: error});
    }
  });
});

exports('transaction', (queries) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(queries); }
      const success = await exports.oxmysql.transaction_async(queries);
      if (needs_debugging) { console.log(success); }
      resolve({result: success, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: false, error: true, msg: error});
    }
  });
});

exports('update', (query, args) => {
  return new Promise(async (resolve) => {
    try {
      const needs_debugging = CheckDebug(GetInvokingResource());
      if (needs_debugging) { console.log(query, args); }
      const affectedRows = await exports.oxmysql.update_async(query, args);
      if (needs_debugging) { console.log(affectedRows); }
      resolve({result: affectedRows, error: false, msg: ""});
    } catch (error) {
      console.log("ERROR: ", error);
      resolve({result: -1, error: true, msg: error});
    }
  });
});