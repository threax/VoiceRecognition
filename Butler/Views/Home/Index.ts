import * as standardCrudPage from 'hr.widgets.StandardCrudPage';
import * as startup from 'clientlibs.startup';
import * as deepLink from 'hr.deeplink';
import { AppCommandSetCrudInjector } from 'clientlibs.AppCommandSetCrudInjector';
import { CrudTableRowControllerExtensions, CrudTableRowController } from 'hr.widgets.CrudTableRow';
import * as controller from 'hr.controller';
import * as client from 'clientlibs.ServiceClient';

class CommandSetRow extends CrudTableRowControllerExtensions {
    public static get InjectorArgs(): controller.InjectableArgs {
        return [];
    }

    private data: client.AppCommandSetResult;

    public rowConstructed(row: CrudTableRowController, bindings: controller.BindingCollection, data: any): void {
        bindings.setListener(this);
        this.data = data;
    }



    public async execute(evt: Event): Promise<void> {
        await this.data.execute();
    }
}

var injector = AppCommandSetCrudInjector;

var builder = startup.createBuilder();
builder.Services.addTransient(CrudTableRowControllerExtensions, CommandSetRow);
deepLink.addServices(builder.Services);
standardCrudPage.addServices(builder, injector);
standardCrudPage.createControllers(builder, new standardCrudPage.Settings());