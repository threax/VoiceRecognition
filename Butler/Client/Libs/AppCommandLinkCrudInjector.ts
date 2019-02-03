import * as client from 'clientlibs.ServiceClient';
import * as hyperCrud from 'hr.widgets.HypermediaCrudService';
import * as di from 'hr.di';

export class AppCommandLinkCrudInjector extends hyperCrud.AbstractHypermediaPageInjector {
    public static get InjectorArgs(): di.DiFunction<any>[] {
        return [client.EntryPointInjector];
    }

    constructor(private injector: client.EntryPointInjector) {
        super();
    }

    async list(query: any): Promise<hyperCrud.HypermediaCrudCollection> {
        var entry = await this.injector.load();
        return entry.listAppCommandLinks(query);
    }

    async canList(): Promise<boolean> {
        var entry = await this.injector.load();
        return entry.canListAppCommandLinks();
    }

    public getDeletePrompt(item: client.AppCommandLinkResult): string {
        return "Are you sure you want to delete the appCommandLink?";
    }

    public getItemId(item: client.AppCommandLinkResult): string | null {
        return String(item.data.appCommandLinkId);
    }

    public createIdQuery(id: string): client.AppCommandLinkQuery | null {
        return {
            appCommandLinkId: id
        };
    }
}