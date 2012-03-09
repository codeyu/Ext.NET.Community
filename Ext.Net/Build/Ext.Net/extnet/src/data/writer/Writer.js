Ext.data.writer.Writer.override({
    write : function (request) {
        var operation = request.operation,            
            record,
            records   = operation.records || [],
            len       = records.length,
            i         = 0,
            data      = [];        

        for (; i < len; i++) {
            record = records[i];

            if (this.filterRecord && this.filterRecord(record) === false) {
                continue;
            }

            data.push(this.getRecordData(record, operation));
        }
        return this.writeRecords(request, data);
    },

    isSimpleField : function (f) {
        var type = f && f.type ? f.type.type : "";

        return type === "int" || type === "float" || type === "boolean" || type === "date";
    },

    setValue : function (data, name, value, field) {
        if (Ext.isEmpty(value, false) && this.isSimpleField(field)) {
            switch (field.submitEmptyValue) {
                case "null":
                    data[name] = null;        
                    break;
                case "emptystring":
                    data[name] = "";        
                    break;
            }
        }
        else {
            data[name] = value;
        }
    },

    getRecordData : function (record, operation) {
        var isPhantom = record.phantom === true,
            writeAll = this.writeAllFields || isPhantom,
            nameProperty = this.nameProperty,
            fields = record.fields,
            data = {},
            changes,
            name,
            field,
            key,
            value;
        
        if (writeAll) {
            fields.each(function (field) {
                if (this.filterField && this.filterField(record, field, record.get(field.name)) === false) {
                    return;
                }
            
                if (field.persist) {
                    name = field[nameProperty] || field.name;
                    value = record.get(field.name);
                    
                    this.setValue(data, name, value, field);
                }
            }, this);
        } else {
            // Only write the changes
            changes = record.getChanges();
            for (key in changes) {
                if (this.filterField && this.filterField(record, key, changes[key]) === false) {
                    continue;
                }
                if (changes.hasOwnProperty(key)) {
                    field = fields.get(key);
                    name = field[nameProperty] || field.name;
                    value = changes[key];

                    this.setValue(data, name, value, field);                   
                }
            }           
        }
        
        if (isPhantom) {
            if (operation && operation.records.length > 1) {
                // include clientId for phantom records, if multiple records are being written to the server in one operation.
                // The server can then return the clientId with each record so the operation can match the server records with the client records
                data[record.clientIdProperty] = record.internalId;
            }
        } else {
            // always include the id for non phantoms
            data[record.idProperty] = record.getId();
        }

        if ((this.excludeId && data.hasOwnProperty(record.idProperty)) || 
           (this.skipIdForPhantomRecords !== false && data.hasOwnProperty(record.idProperty) && isPhantom)) {
            delete data[record.idProperty];
        }

        if (this.skipPhantomId && data.hasOwnProperty(record.clientIdProperty) && isPhantom) {
            delete data[record.clientIdProperty];
        }
        return data;
    }
});