
// @source core/utils/TaskManager.js

Ext.net.TaskResponse = { 
    stopTask : -1, 
    stopAjax : -2 
};

Ext.define("Ext.net.TaskManager", {
    extend : "Ext.util.Observable",    

    constructor : function (config) {
        this.callParent(arguments);
        Ext.Function.defer(this.initManager, this.autoRunDelay || 50, this);
    },
    
    getTasks : function () {
        return this.tasks;
    },

    initManager : function () {
        this.runner = new Ext.util.TaskRunner(this.interval || 10);

        var task;        
        this.tasks = [];
        this.tasksConfig = this.tasksConfig || [];

        for (var i = 0; i < this.tasksConfig.length; i++) {
            task = this.createTask(this.tasksConfig[i]);
            this.tasks.push(task);
            
            if (task.executing && task.autoRun) {
                this.startTask(task);
            }
        }
    },
    
    addTask : function (taskConfig) {
        var task = this.createTask(taskConfig);
        this.tasks.push(task);
        
        if (task.executing && task.autoRun) {
            this.startTask(task);
        }
    },
    
    removeTask : function (task) {
        task = this.getTask(task);
        if (!Ext.isEmpty(task)) {
            this.stopTask(task);
            this.tasks.remove(task);
        }
    },

    getTask : function (id) {
        if (typeof id == "object") {
            return id;
        } else if (typeof id == "string") {
            for (var i = 0; this.tasks.length; i++) {
                if (this.tasks[i].id == id) {
                    return this.tasks[i];
                }
            }
        } else if (typeof id == "number") {
            return this.tasks[id];
        }
        return null;
    },

    startTask : function (task) {
        if (this.executing) {
            return;
        }

        task = this.getTask(task);

        if (task.onstart) {
            task.onstart.apply(task.scope || task);
        }

        this.runner.start(task);
    },

    stopTask : function (task) { 
        this.runner.stop(this.getTask(task)); 
    },

    startAll : function () {
        for (var i = 0; i < this.tasks.length; i++) {
            this.startTask(this.tasks[i]);
        }
    },

    stopAll : function () { 
        this.runner.stopAll(); 
    },

    //private
    createTask : function (config) {
        return Ext.apply({}, config, {
            owner     : this,
            executing : true,
            interval  : 1000,
            autoRun   : true,
            waitPreviousRequest : false,
            
            onStop    : function (t) {
                this.executing = false;
                
                if (this.onstop) {
                    this.onstop();
                }
            },
            
            onRemoteComplete : function () {
                delete this._ts;
                if (this.runOnComplete && this.executing) {
                    this.runOnComplete = false;
                    this.run();                    
                }

                if (!this.executing) {
                    this.runOnComplete = false;
                }
            },

            run : function () {
                if (this.clientRun) {
                    var rt = this.clientRun.apply(arguments);

                    if (rt === Ext.net.TaskResponse.stopAjax) {
                        return;
                    } else if (rt === Ext.net.TaskResponse.stopTask) {
                        return false;
                    }
                }

                if (this.waitPreviousRequest && this._ts) {
                    this.runOnComplete = true;
                    return;
                }
                
                if (this.serverRun) {
                    var o = this.serverRun();
                    if (!o.alreadySetComplete) {
                        if (o.userComplete && Ext.isFunction(o.userComplete)) {
                            o.userComplete = Ext.Function.createSequence(o.userComplete, Ext.Function.bind(this.onRemoteComplete, this), this);
                        }
                        else {
                            o.userComplete = Ext.Function.bind(this.onRemoteComplete, this);
                        }
                        o.alreadySetComplete = true;
                    }
                    o.control = this.owner;
                    this._ts = Ext.net.DirectEvent.request(o);
                }
            }
        });
    },
    
    destroy : function () {
        Ext.net.ComponentMgr.unregisterId(this);
        
        this.stopAll();
        delete this.tasks;
        delete this.runner;
    }
});