import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class AppCommandSetCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listAppCommandSets(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListAppCommandSets();
    }

    public getDeletePrompt(item: client.AppCommandSetResult): string {
        return "Are you sure you want to delete the appCommandSet?";
    }

    public getItemId(item: client.AppCommandSetResult): string | null {
        return String(item.data.appCommandSetId);
    }

    public createIdQuery(id: string): client.AppCommandSetQuery | null {
        return {
            appCommandSetId: id
        };
    }
}