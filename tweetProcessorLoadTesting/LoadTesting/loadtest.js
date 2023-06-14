export {populateTimelineLoadTest} from './populateTimelineLoadTest.js';
export {populateTimelineByUserLoadTest} from './populateTimelineByUserLoadTest.js';

export const options = {
    scenarios: {
        scenariopopulateTimeline: {
            executor: 'shared-iterations',
            exec: 'populateTimelineLoadTest',
            vus: 10,
            iterations: 200,
        },
        scenariopopulateTimelinebyID:{
            executor: 'shared-iterations',
            exec: 'populateTimelineByUserLoadTest',
            vus: 10,
            iterations: 200,
        },
        // scenarioCreateFollow:{executor: 'shared-iterations',
        //     exec: 'registerLoadTest',
        //     vus: 10,
        //     iterations: 200,}
    }
}